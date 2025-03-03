namespace graphics_pack.Models;

public class CircleModel : IShape
{
    public IEnumerable<PointInfo> GetIndexes()
    {
        if (Algorithm == AlgorithmType.BresenhamCircle)
        {
            return CircleBres();
        }
        else
            throw new NonValidAlgorithmException();
    }

    public string name { get; set; }
    public string color { get; set; }
    public string? ImgSrc { get; set; }
    public AlgorithmType Algorithm { get; set; } = AlgorithmType.BresenhamCircle;
    
    public int X { get; set; }
    public int Y { get; set; }
    public int Radius { get; set; }

    private IEnumerable<BresPointInfo> CircleBres()
    {

            int x = 0, y = Radius;
            int Pk = 3 - 2 * Radius;
            int OldP = Pk;
            yield return new BresPointInfo{x = X-x, y = Y+y, Pk = OldP};
            yield return new BresPointInfo{x = X+x, y = Y+y, Pk = OldP};
            yield return new BresPointInfo{x = X+x, y = Y-y, Pk = OldP};
            yield return new BresPointInfo{x = X-x, y = Y-y, Pk = OldP};
            yield return new BresPointInfo{x = X+y, y = Y+x, Pk = OldP};
            yield return new BresPointInfo{x = X-y, y = Y+x, Pk = OldP};
            yield return new BresPointInfo{x = X+y, y = Y-x, Pk = OldP};
            yield return new BresPointInfo{x = X-y, y = Y-x, Pk = OldP};
            
            
            while (y >= x){
      
                // check for decision parameter
                // and correspondingly 
                // update d, y
                
                if (Pk > 0) {
                    y--; 
                    Pk = Pk + 4 * (x - y) + 10;
                }
                else
                    Pk = Pk + 4 * x + 6;

                // Increment x after updating decision parameter
                x++;
        
                // Draw the circle using the new coordinates
                yield return new BresPointInfo{x = X-x, y = Y+y, Pk = OldP};
                yield return new BresPointInfo{x = X+x, y = Y+y, Pk = OldP};
                yield return new BresPointInfo{x = X+x, y = Y-y, Pk = OldP};
                yield return new BresPointInfo{x = X-x, y = Y-y, Pk = OldP};
                yield return new BresPointInfo{x = X+y, y = Y+x, Pk = OldP};
                yield return new BresPointInfo{x = X-y, y = Y+x, Pk = OldP};
                yield return new BresPointInfo{x = X+y, y = Y-x, Pk = OldP};
                yield return new BresPointInfo{x = X-y, y = Y-x, Pk = OldP};
                OldP = Pk;
            }
    }
    
    
}