includesBehavior: aClass ThatOf: aSuperclass
	"Return the equivalent of 
		aClass includesBehavior: aSuperclass.
	Note: written for efficiency and better inlining (only 1 temp)"
	| theClass |
	self inline: true.
	(((theClass _ aClass) = aSuperclass) "aClass == aSuperclass"
		or:[aSuperclass = nilObj]) "every class inherits from nil"
			ifTrue:[^true].
	[(theClass _ self superclassOf: theClass) = aSuperclass ifTrue:[^true].
	theClass ~= nilObj] whileTrue.
	^false