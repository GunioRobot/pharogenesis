fixObsoleteReferences
	"SmalltalkImage current fixObsoleteReferences"
	| informee obsoleteBindings obsName realName realClass |

	Smalltalk garbageCollect; garbageCollect.

	Preference allInstances do: [:each | 
		informee _ each instVarNamed: #changeInformee.
		((informee isKindOf: Behavior)
			and: [informee isObsolete])
			ifTrue: [
				Transcript show: 'Preference: '; show: each name; cr.
				each instVarNamed: #changeInformee put: (Smalltalk at: (informee name copyReplaceAll: 'AnObsolete' with: '') asSymbol)]].
 
	CompiledMethod allInstances do: [:method |
		obsoleteBindings _ method literals select: [:literal |
			literal isVariableBinding
				and: [literal value isBehavior]
				and: [literal value isObsolete]].
		obsoleteBindings do: [:binding |
			obsName _ binding value name.
			Transcript show: 'Binding: '; show: obsName; cr.
			realName _ obsName copyReplaceAll: 'AnObsolete' with: ''.
			realClass _ Smalltalk at: realName asSymbol ifAbsent: [UndefinedObject].
			binding isSpecialWriteBinding
				ifTrue: [binding privateSetKey: binding key value: realClass]
				ifFalse: [binding key: binding key value: realClass]]].


	Behavior flushObsoleteSubclasses.
	Smalltalk garbageCollect; garbageCollect.
	SystemNavigation default obsoleteBehaviors size > 0
		ifTrue: [
			SystemNavigation default obsoleteBehaviors inspect.
			self error:'Still have obsolete behaviors. See inspector'].

