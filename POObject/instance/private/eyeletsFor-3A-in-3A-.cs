eyeletsFor: aHalfedge in: extent
	| eyelets start end axis center rotation nib scale abscissa ordinate omega pos |
	eyelets _ OrderedCollection new: Subdivisions + 1.
	aHalfedge origin z = 0
		ifTrue: [start _ aHalfedge origin. end _ aHalfedge destination]
		ifFalse: [start _ aHalfedge destination. end _ aHalfedge origin].
	start _ start asB3DVector3.
	end _ end asB3DVector3.
	axis _ end - start cross: 0 @ 0 @ 1.
	center _ end copy z: 0.
	abscissa _ (center - start) length.
	ordinate _ end z.
	omega _ 90.0 / Subdivisions.
	scale _ (end - center) length.
	nib _ end - center / scale.
	rotation _ (B3DRotation angle: omega axis: axis) asMatrix4x4.
	1 to: Subdivisions do: 
		[:segment |
		pos _ nib * scale + center.
		eyelets add: (self b3dVertexAt: pos normal: nib in: extent).
		nib _ rotation localPointToGlobal: nib.
		scale _ (((omega * segment) degreeCos * ordinate) squared + ((omega * segment) degreeSin * abscissa) squared) sqrt].
	pos _ start.
	eyelets add: (self b3dVertexAt: pos normal: nib in: extent).
	^ eyelets