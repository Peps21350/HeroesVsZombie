using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class RobotMechanic : MonoBehaviour
    {
        //public Button[] buttons;
        private bool state_spawn = false;
        public GameObject[] robot;
        [NonReorderable] public  NpcRobot[] created_robots;
        private int count_robots;
        
        private Vector3 result;
        [NonReorderable]public float allHealth = 0;

        private bool type_robot;


        
        public void SpawnRobotUp()
        {
            if (state_spawn)
            {
                result = new Vector3(250f, 550f, 0);
                CreatingRobot(result);
                RobotMovement(1000000);
            }
            state_spawn = false;
        }
        
        public void SpawnRobotMidle()
        {
            if (state_spawn)
            {
                result = new Vector3(250f, 427f, 0);
                CreatingRobot(result);
                RobotMovement(1000000);
            }
            state_spawn = false;
        }
        
        public void SpawnRobotDown()
        {
            if (state_spawn)
            {
                result = new Vector3(250f, 287f, 0);
                CreatingRobot(result);
                RobotMovement(1000000);
            }
            state_spawn = false;
        }
        
        
        public void CreatingRobot(Vector3 result_coords)
        {
            created_robots = new NpcRobot[count_robots];
            if (type_robot)
            {
                for (int i = 0; i < count_robots; i++)
                {
                    //int rand = Random.Range(0, arrayZombies.Length);
                    created_robots[i] = Instantiate(robot[0], result_coords, Quaternion.identity).GetComponent<NpcRobot>();
                    created_robots[i].transform.localScale = new Vector3(robot[0].transform.localScale.x, robot[0].transform.localScale.y, 1);
                    created_robots[i].init("Robot1", 90,850000,15,10);
                    AllHPRobots();
                }
            }
            if (!type_robot)
            {
                for (int i = 0; i < count_robots; i++)
                {
                    //int rand = Random.Range(0, arrayZombies.Length);
                    created_robots[i] = Instantiate(robot[1], result_coords, Quaternion.identity).GetComponent<NpcRobot>();
                    created_robots[i].transform.localScale = new Vector3(robot[1].transform.localScale.x, robot[1].transform.localScale.y, 1);
                    created_robots[i].init("Robot2", 50,1000000,25,10);
                    AllHPRobots();
                }
            }
        }
        
        public void RobotMovement(float speed)
        {
            foreach (var robot_movement in created_robots)
            {
                robot_movement.GetComponent<Rigidbody2D>().AddForce(new Vector2(Time.deltaTime * robot_movement.speedOfMovement, 0));
            }
            
        }
        

        public void ClickOnButtonsRobot()
        {
            type_robot = true;
            state_spawn = true;
            count_robots = +1;
            
        }
        
        
        public void ClickOnButtonsRobot2()
        {
            type_robot = false;
            state_spawn = true;
            count_robots = +1;
        }
        
        private void IsAlive()
        {
            foreach (var dead_robot in created_robots)
            {
                if (dead_robot.currentHealth <= 0)
                {
                    Destroy(dead_robot);
                }
            }
        }
        
        //private void Update()
        //{
        //    AllHPInfantryman();
        //    //CheckEndMovement();
        //}


        private float AllHPRobots()
        {
            if (created_robots[0] != null)
            {
                foreach (var robot in created_robots)
                {
                    allHealth += robot.currentHealth;
                }
            }
            return allHealth;
        }
        
        
    }
}