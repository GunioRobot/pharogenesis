explainInst: string 
	"Is string an instance variable of this class?"
	| classes cls |

	(model respondsTo: #selectedClassOrMetaClass) ifTrue: [
		cls _ model selectedClassOrMetaClass].
	cls ifNil: [^ nil].	  "no class known"
	classes _ (Array with: cls)
				, cls allSuperclasses.
	classes _ classes detect: [:each | (each instVarNames
			detect: [:name | name = string] ifNone: [])
			~~ nil] ifNone: [^nil].
	classes _ classes printString.
	^ '"is an instance variable of the receiver; defined in class ' , classes , 
		'"\' withCRs , classes , ' systemNavigation browseAllAccessesTo: ''' , string , ''' from: ', classes, '.'