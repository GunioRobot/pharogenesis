methodReference 
	| cls sel |
	cls := self selectedClassOrMetaClass.
	sel := self selectedMessageName.
	cls isNil | sel isNil ifTrue: [^nil].
	^ MethodReference class: cls selector: sel