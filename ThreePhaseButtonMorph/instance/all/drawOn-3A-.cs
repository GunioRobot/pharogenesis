drawOn: aCanvas

	state == #off ifTrue: [
		offImage ifNotNil: [aCanvas image: offImage at: bounds origin]].
	state == #pressed ifTrue: [
		pressedImage ifNotNil: [aCanvas image: pressedImage at: bounds origin]].
	state == #on ifTrue: [
		image ifNotNil: [aCanvas image: image at: bounds origin]].