mapUniClasses
	"For new Uniclasses, map their class vars to the new objects.  And their additional class instance vars.  (scripts slotInfo) and cross references like (player321)."

"Uniclasses use class vars to hold onto siblings who are referred to in code"
| pp |
pp _ Object class instSize + 1.
uniClasses do: [:playersClass | "values = new ones"
	playersClass classPool associationsDo: [:assoc |
		assoc value: (assoc value veryDeepCopyWith: self)].
	playersClass scripts: (playersClass privateScripts veryDeepCopyWith: self).	"pp+0"
	"(pp+1) slotInfo was deepCopied in copyUniClass and that's all it needs"
	pp+2 to: playersClass class instSize do: [:ii | 
		playersClass instVarAt: ii put: 
			((playersClass instVarAt: ii) veryDeepCopyWith: self)].
	].
