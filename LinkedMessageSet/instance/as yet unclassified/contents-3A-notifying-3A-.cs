contents: aText notifying: aController
	"override to handle class dfn and comment"

	self setClassAndSelectorIn: [:class :selector | 
		selector first isUppercase ifFalse: [
			^ super contents: aText notifying: aController].
		selector = #Comment ifTrue: [
			class comment: aText.
 			self unlock.  ^ false].
		selector = #Definition ifTrue: [
			"self defineClass: aText notifying: aController."
			class subclassDefinerClass
				evaluate: aText
				notifying: aController
				logged: true.
			self unlock.
 			^ false].
		selector = #Hierarchy ifTrue: [
			self inform: 'To change the hierarchy, edit the class definitions'. ^ false].
		].