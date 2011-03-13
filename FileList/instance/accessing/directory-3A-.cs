directory: dir
	"Set the path of the volume to be displayed."
	
	self okToChange ifFalse: [^ self].
	self modelSleep.
	directory := dir ifNil: [FileDirectory on: ''].
	self modelWakeUp.
	sortMode == nil ifTrue: [sortMode := #date].
		volList := ((Array with: '[]'), directory pathParts)  
				withIndexCollect: [:each :i | ( String new: i-1 withAll: $ ), each].
	volListIndex := volList size.	
	self changed: #relabel.
	self changed: #volumeList.
	self pattern: pattern