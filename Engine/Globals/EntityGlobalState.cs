using Voxelized.Engine.ECS;
using Voxelized.Engine.DataStructures;

namespace Voxelized.Engine.Globals;
public static class EntityGlobalState {
  private static List<Entity>? _entities;

  public static void ClearEntities() {
    _entities = null;
  }

  public static void SetEntities(List<Entity> entities) {
    if(_entities != null) {
      throw new Exception("EntityGlobalState: List is already created, in order to create new one use ClearEntities() first");
    } else {
      _entities = entities;
    }
  }

  public static List<Entity> GetEntities() {
    if(_entities == null) {
      return new List<Entity>();
    }
    return _entities;
  }
}