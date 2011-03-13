contributorsNotSignatories
	"SystemNavigation default contributorsNotSignatories"
	
	| stamp signatories initials answer |
	answer := Dictionary new.
	signatories := self signatories.
	self allBehaviorsDo: [ :behavior |
		behavior methodsDo: [ :compiledMethod |
			stamp := compiledMethod timeStamp.
			stamp notEmpty ifTrue: [
				initials :=  compiledMethod timeStamp substrings first.
				(signatories includes: initials) ifFalse: [
					(answer at: initials ifAbsentPut: [OrderedCollection new])
						add: (compiledMethod selector -> compiledMethod methodClass)]]]].
	^answer