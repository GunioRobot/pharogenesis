variableGetterBlockIn: aContext

	| temps index ivars |

	(self type = 4 and: [self key isVariableBinding]) ifTrue: [
		^[self key value]
	].
	aContext ifNil: [^nil].
	self isSelfPseudoVariable ifTrue: [^[aContext receiver]].
	self type = 1 ifTrue: [
		ivars _ aContext receiver class allInstVarNames.
		index _ ivars indexOf: self name ifAbsent: [^nil].
		^[aContext receiver instVarAt: index]
	].
	self type = 2 ifTrue: [
		temps _ aContext tempNames.
		index _ temps indexOf: self name ifAbsent: [^nil].
		^[aContext tempAt: index]
	].
	^nil
