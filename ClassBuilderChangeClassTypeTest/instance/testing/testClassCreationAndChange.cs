testClassCreationAndChange

    |  success |

  [baseClass := Object subclass: self baseClassName
		instanceVariableNames: ''
		classVariableNames: ''
		poolDictionaries: ''
		category: 'Kernel-Tests-ClassBuilder'.
  self assert: baseClass isPointers.
  self deny: baseClass isVariable.
  success := true.
     [Object variableSubclass: self baseClassName
		instanceVariableNames: ''
		classVariableNames: ''
		poolDictionaries: ''
		category: 'Kernel-Tests-ClassBuilder'.]
      on: Error
      do: [:exception |  success := false].
  self assert: (success and: [baseClass isVariable]).
 ] ensure: [self cleanup]
  
  