exD10
	"VRMLNodeParser parseString: VRMLNodeParser exD10"
^'#VRML V2.0 utf8

Shape { 
    geometry PointSet {
        coord DEF mypts Coordinate { point [ 0 0 0, 2 2 2, 3 3 3 ] }
        color Color { color [ 1 0 0, 0 1 0, 0 0 1 ] }
    }
}

Transform {
    translation 2 0 0

    children Shape {
        geometry PointSet {
	    coord USE mypts
	    color Color { color [ .5 .5 0, 0 .5 .5, 1 1 1 ] }
        }
    }
}
'