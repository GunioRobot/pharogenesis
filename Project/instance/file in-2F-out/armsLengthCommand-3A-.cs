armsLengthCommand: aCommand
	| pvm |
	"Set things up so that this aCommand is sent to self as a message after jumping to the parentProject.  For things that can't be executed while in this project, such as saveAs, loadFromServer, storeOnServer.  See ProjectViewMorph step."

	parentProject ifNil: [^ self inform: 'The top project can''t do that'].
	pvm _ parentProject findProjectView: self.
	parentProject isMorphic
		ifTrue: [
			pvm setProperty: #armsLengthCmd toValue: aCommand.
			pvm setProperty: #wasStepping toValue: false.
			pvm world startStepping: pvm]
		ifFalse: [
			pvm armsLengthCommand: aCommand.
			].
	self exit.