initializeBlobShape

	| verts modifier |
	verts := {59@40. 74@54. 79@74. 77@93. 57@97. 37@97. 22@83. 15@67. 22@50. 33@35. 47@33}.
	modifier := 0 @ 0.
	(self quadNumber = 2) ifTrue: [ modifier := 0 @ 75].
	(self quadNumber = 3) ifTrue: [ modifier := 75 @ 0].
	(self quadNumber = 4) ifTrue: [ modifier := 75 @ 75].
	verts := verts + modifier.
	self 
		vertices: verts
		color: self color
		borderWidth: 1
		borderColor: Color black