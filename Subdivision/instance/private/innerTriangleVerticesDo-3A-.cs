innerTriangleVerticesDo: aBlock
	startingEdge first triangleEdges: (stamp _ stamp + 1) do:
		[:e1 :e2 :e3|
			self assert:[e1 origin = e3 destination].
			self assert:[e2 origin = e1 destination].
			self assert:[e3 origin = e2 destination].
			(e1 isExteriorEdge or:[e2 isExteriorEdge or:[e3 isExteriorEdge]]) ifFalse:[
				aBlock value: e1 origin value: e2 origin value: e3 origin.
			].
		].
