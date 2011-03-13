fixObsoleteReferences
	"SmalltalkImage current fixObsoleteReferences.
	SystemNavigation default obsoleteBehaviors size > 0
		ifTrue: [ SystemNavigation default obsoleteBehaviors inspect.
			self error:'Still have obsolete behaviors. See inspector']"

	| informee obsoleteBindings obsName realName realClass |

	Smalltalk garbageCollect; garbageCollect.

	Preference allInstances do: [:each | 
		informee := each instVarNamed: #changeInformee.
		((informee isKindOf: Behavior)
			and: [informee isObsolete])
			ifTrue: [
				Transcript show: 'Preference: '; show: each name; cr.
				each instVarNamed: #changeInformee put: (Smalltalk at: (informee name copyReplaceAll: 'AnObsolete' with: '') asSymbol)]].
 
	CompiledMethod allInstances do: [:method |
		obsoleteBindings := method literals select: [:literal |
			literal isVariableBinding
				and: [literal value isBehavior]
				and: [literal value isObsolete]].
		obsoleteBindings do: [:binding |
			obsName := binding value name.
			Transcript show: 'Binding: '; show: obsName; cr.
			realName := obsName copyReplaceAll: 'AnObsolete' with: ''.
			realClass := Smalltalk at: realName asSymbol ifAbsent: [UndefinedObject].
			binding key: binding key value: realClass]].


	Behavior flushObsoleteSubclasses.
	Smalltalk garbageCollect; garbageCollect.



