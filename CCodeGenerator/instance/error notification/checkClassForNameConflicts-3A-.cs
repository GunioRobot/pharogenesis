checkClassForNameConflicts: aClass
	"Verify that the given class does not have constant, variable, or method names that conflict with those of previously added classes. Raise an error if a conflict is found, otherwise just return."

	"check for constant name collisions"
	aClass classPool associationsDo: [ :assoc |
		(constants includesKey: assoc key asString) ifTrue: [
			self error: 'Constant was defined in a previously added class: ', assoc key.
		].
	].
	"ikp..."
	aClass sharedPools do: [:pool |
		pool bindingsDo: [ :assoc |
			(constants includesKey: assoc key asString) ifTrue: [
				self error: 'Constant was defined in a previously added class: ', assoc key.
			].
		].
	].

	"check for instance variable name collisions"
	aClass instVarNames do: [ :varName |
		(variables includes: varName) ifTrue: [
			self error: 'Instance variable was defined in a previously added class: ', varName.
		].
	].

	"check for method name collisions"
	aClass selectors do: [ :sel |
		(methods includesKey: sel) ifTrue: [
			self error: 'Method was defined in a previously added class: ', sel.
		].
	].