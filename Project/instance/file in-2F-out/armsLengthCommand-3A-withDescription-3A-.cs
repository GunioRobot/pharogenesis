armsLengthCommand: aCommand withDescription: aString
	| pvm tempProject foolingForm tempCanvas bbox crossHatchColor stride |
	"Set things up so that this aCommand is sent to self as a message
after jumping to the parentProject.  For things that can't be executed
while in this project, such as saveAs, loadFromServer, storeOnServer.  See
ProjectViewMorph step."

	self isMorphic ifTrue: [
		world borderWidth: 0.	"get rid of the silly default border"
		tempProject _ Project newMorphic.
		foolingForm _ world imageForm.		"make them think they never left"
		tempCanvas _ foolingForm getCanvas.
		bbox _ foolingForm boundingBox.
		crossHatchColor _ Color yellow alpha: 0.3.
		stride _ 20.
		10 to: bbox width by: stride do: [ :x |
			tempCanvas fillRectangle: (x@0 extent: 1@bbox height) fillStyle: crossHatchColor.
		].
		10 to: bbox height by: stride do: [ :y |
			tempCanvas fillRectangle: (0@y extent: bbox width@1) fillStyle: crossHatchColor.
		].

		tempProject world color: (InfiniteForm with: foolingForm).
		tempProject projectParameters 
			at: #armsLengthCmd 
			put: (
				DoCommandOnceMorph new
					addText: aString;
					actionBlock: [
						self doArmsLengthCommand: aCommand.
					] fixTemps
			).
		tempProject projectParameters 
			at: #deleteWhenEnteringNewProject 
			put: true.
		tempProject enter.
	] ifFalse: [
		parentProject ifNil: [^ self inform: 'The top project can''t do that'].
		pvm _ parentProject findProjectView: self.
		pvm armsLengthCommand: {self. aCommand}.
		self exit.
	].
