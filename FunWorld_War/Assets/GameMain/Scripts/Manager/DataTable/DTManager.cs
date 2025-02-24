public class DTManager
{
        public DTNPCManager  DTNPCManager;
        public DTAttributeManager DTAttributeManager;
        public void InitAllDTManager()
        { 
                DTNPCManager = new DTNPCManager();
                DTNPCManager.Initialize();
                DTAttributeManager = new DTAttributeManager(); 
                DTAttributeManager.Initialize();
        }
}