drawOn: aCanvas

	state == #off ifTrue: [
		offImage ifNotNil: [aCanvas paintImage: offImage at: bounds origin]].
	state == #pressed ifTrue: [
		pressedImage ifNotNil: [aCanvas paintImage: pressedImage at: bounds origin]].
	state == #on ifTrue: [
		image ifNotNil: [aCanvas paintImage: image at: bounds origin]].