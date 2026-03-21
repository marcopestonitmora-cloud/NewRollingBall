using UnityEngine;

public class Grappling : MonoBehaviour
{
   [Header("References")] 
   [SerializeField] private PlayerMovementSystem movementGrappling;
   [SerializeField] private Transform camera;
   [SerializeField] private Transform gunTip;
   public LayerMask whatIsGrappable;

   [Header("Grappling")]
   public float maxGrapplingDistance;
   public float grappleStartDelay;
   public Vector3 grapplePoint;
   private RaycastHit hit;
   [SerializeField] private float grappleCooldown;
   private float grappleCooldownTimer;
   [SerializeField]public LineRenderer lineRenderer;
   
   [Header("Grapple Pull")]
   [SerializeField] private float grapplePullForce = 10f;
   [SerializeField] private float maxPullSpeed = 20f;

   
   [Header("Input")]
   public KeyCode grabKey = KeyCode.Mouse1;
   private bool isGrappling;

   void Start()
   {
      movementGrappling = GetComponent<PlayerMovementSystem>();
   }

   public void Update()
   {
      if (Input.GetKeyDown(grabKey))
      {
         StartGrappling();
      }

      if (grappleCooldownTimer > 0)
      {
         grappleCooldownTimer -= Time.deltaTime;
      }
      
      if (isGrappling)
      {
         CheckGrappleDistance();
      }

   }

   public void LateUpdate()
   {
      if (isGrappling)
      {
         lineRenderer.SetPosition(0, gunTip.position);
      }
   }

   //METODOS
   // ReSharper disable Unity.PerformanceAnalysis
   public void StartGrappling()
   {
      //If u have cooldown on the grapple u cant use it
      if (grappleCooldownTimer > 0)
      {
         return;
      }
      
      isGrappling = true;
      movementGrappling.freeze = true;

      if (Physics.Raycast(gunTip.position, camera.forward, out hit, maxGrapplingDistance, whatIsGrappable))
      {
         grapplePoint = hit.point;
         Invoke(nameof(ExecuteGrappling), grappleStartDelay); //Llamamos a la siguiente funcion pero con un pequeño delay
      }
      else
      {
         //Si no hiteas, aun asi sale el gancho pero sin impactar
         grapplePoint = gunTip.position + camera.forward * maxGrapplingDistance;
         Invoke(nameof(StopGrappling), grappleStartDelay);
      }
      
      lineRenderer.enabled = true;
      lineRenderer.SetPosition(1, grapplePoint);
   }
   
   public void ExecuteGrappling()
   {
      movementGrappling.freeze = false;
      
      Vector3 direction = (grapplePoint - transform.position).normalized;

      // Limitar velocidad máxima
      if (movementGrappling.Main.rb.linearVelocity.magnitude > maxPullSpeed)
      {
         movementGrappling.Main.rb.linearVelocity = movementGrappling.Main.rb.linearVelocity.normalized * maxPullSpeed;
      }

      // Aplicar impulso solo si no supera el límite
      if (movementGrappling.Main.rb.linearVelocity.magnitude < maxPullSpeed)
      {
         movementGrappling.Main.rb.AddForce(direction * grapplePullForce, ForceMode.Impulse);
      }
   }

   public void StopGrappling()
   {
      movementGrappling.freeze = false;
      isGrappling = false;
      grappleCooldownTimer = grappleCooldown;
      lineRenderer.enabled = false;
   }
   
   private void CheckGrappleDistance()
   {
      float distance = Vector3.Distance(transform.position, grapplePoint);

      if (distance < 5f)
      {
         StopGrappling();
      }
   }
}
