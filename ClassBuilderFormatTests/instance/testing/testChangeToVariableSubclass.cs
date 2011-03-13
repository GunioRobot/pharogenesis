testChangeToVariableSubclass
	"Ensure that the invariants for superclass/subclass format are preserved"
	baseClass := Object subclass: self baseClassName
		instanceVariableNames: ''
		classVariableNames: ''
		poolDictionaries: ''
		category: 'Kernel-Tests-ClassBuilder'.
	[
		self shouldnt:[baseClass := Object variableSubclass: self baseClassName
			instanceVariableNames: ''
			classVariableNames: ''
			poolDictionaries: ''
			category: 'Kernel-Tests-ClassBuilder'] raise: Error.

	] ensure:[self cleanup].