compile: text classified: category withStamp: changeStamp notifying: requestor logSource: logSource
	
	| classSideUsersOfBaseTrait message |
	classSideUsersOfBaseTrait _ self baseTrait users select: [:each | each isClassSide].
	classSideUsersOfBaseTrait isEmpty ifFalse: [
		message _ String streamContents: [:stream |
			stream nextPutAll: 'The instance side of this trait is used on '; cr.
			classSideUsersOfBaseTrait
				do: [:each | stream nextPutAll: each name]
				separatedBy: [ stream nextPutAll: ', '].
			stream cr; nextPutAll: ' You can not add methods to the class side of this trait!'].
		^TraitException signal:  message].
	
	^super
		compile: text
		classified: category
		withStamp: changeStamp
		notifying: requestor
		logSource: logSource