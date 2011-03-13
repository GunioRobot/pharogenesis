testCircleInstance
""
"self run: #testCircleInstance" 

| circ |
self assert: (circ := CircleMorph initializedInstance) extent = circ extent x asPoint

