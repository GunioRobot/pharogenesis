renderOn: aRenderer

 " it is not easy to write a fast method that correctly handles the presence or absence of all possible visual features.
Normally, is is not necessary to close the face polygons. In this code triangles *are* closed. When I did not close them, I noticed a crash of the VM. With closed triangles, all works as  it should. This observation indicates the presence of a bug somewhere in the renderer. "

 1 to: faces size do:
    [:idx |  | f vc |
        f := faces at: idx.
        aRenderer
	   trackEmissionColor: true.		"Turn on pre-lit colors"
        faceColors notNil
           ifTrue: [aRenderer color: (faceColors at: idx)].
        aRenderer normal: (faceNormals  at: idx).
        vertexColors notNil
           ifTrue:
             [vc := vertexColors at: idx.
              aRenderer
                drawPolygonAfter:
                  [1 to: f size do:
                       [:j | aRenderer normal: (faceNormals  at: idx).
                            aRenderer color: (vc at: j). 
                            aRenderer vertex: (vertices at: (f at: j))].
                   f size = 3
                     ifTrue: [aRenderer normal: (faceNormals  at: idx).
                               aRenderer color: (vc at: 1). 
                               aRenderer vertex: (vertices at: (f at: 1))]
            ]]
           ifFalse:
             [aRenderer
                drawPolygonAfter:
                  [1 to: f size do:
                       [:j | aRenderer normal: (faceNormals  at: idx).
                            aRenderer vertex: (vertices at: (f at: j))].
                   f size = 3
                     ifTrue: [aRenderer normal: (faceNormals  at: idx).
                               aRenderer color: (vc at: 1). 
                               aRenderer vertex: (vertices at: (f at: 1))]
            ]     ]
    ]