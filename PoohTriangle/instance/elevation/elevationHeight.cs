elevationHeight
	"Compute the elevation height of the receiver"
	| center sum count |
	center _ self center.
	sum _ (center dist: e1 origin) + (center dist: e2 origin) + (center dist: e3 origin).
	count _ 3.
true ifTrue:[^sum / count].
	e1 fanVertices ifNotNilDo:[:vtx|
		vtx do:[:v| sum _ sum + (v dist: center)].
		count _ count + vtx size].
	e2 fanVertices ifNotNilDo:[:vtx|
		vtx do:[:v| sum _ sum + (v dist: center)].
		count _ count + vtx size].
	e3 fanVertices ifNotNilDo:[:vtx|
		vtx do:[:v| sum _ sum + (v dist: center)].
		count _ count + vtx size].
	^sum / count asFloat