checkVariables
	"Check that no indexes of instance vars have changed in certain classes.  If you get an error in this method, an implementation of veryDeepCopyWith: needs to be updated.  The idea is to catch a change while it is still in the system of the programmer who made it.  
	DeepCopier new checkVariables	"

	| str str2 meth |
	str _ '|veryDeepCopyWith: or veryDeepInner: is out of date.'.
	Object instSize = 0 ifFalse: [self error: 'Many implementers of veryDeepCopyWith: are out of date'].
	Morph superclass == Object ifFalse: [self error: 'Morph', str].
	(Morph instVarNames copyFrom: 1 to: 6) = #('bounds' 'owner' 'submorphs' 
			'fullBounds' 'color' 'extension') 
		ifFalse: [self error: 'Morph', str].	"added ones are OK"

	"Every class that implements veryDeepInner: must copy all its inst vars.  Danger is that a user will add a new instance variable and forget to copy it.  So check that the last one is mentioned in the copy method."
	(Smalltalk allClassesImplementing: #veryDeepInner:) do: [:aClass | 
		((aClass compiledMethodAt: #veryDeepInner:) writesField: aClass instSize) ifFalse: [
			aClass instSize > 0 ifTrue: [
				self warnIverNotCopiedIn: aClass sel: #veryDeepInner:]]].
	(Smalltalk allClassesImplementing: #veryDeepCopyWith:) do: [:aClass | 
		meth _ aClass compiledMethodAt: #veryDeepCopyWith:.
		(meth size > 20) & (meth literals includes: #veryDeepCopyWith:) not ifTrue: [
			(meth writesField: aClass instSize) ifFalse: [
				self warnIverNotCopiedIn: aClass sel: #veryDeepCopyWith:]]].

	str2 _ 'Player|copyUniClass and DeepCopier|mapUniClasses are out of date'.
	Behavior instVarNames = #('superclass' 'methodDict' 'format' )
		ifFalse: [self error: str2].
	ClassDescription instVarNames = #('instanceVariables' 'organization' )
		ifFalse: [self error: str2].
	Class instVarNames = #('subclasses' 'name' 'classPool' 'sharedPools' 'environment' 'category' )
		ifFalse: [self error: str2].
	Model superclass == Object ifFalse: [self error: str2].
	Player superclass == Model ifFalse: [self error: str2].
	Model class instVarNames = #() ifFalse: [self error: str2].
	Player class instVarNames = #('scripts' 'slotInfo')
		ifFalse: [self error: str2].
