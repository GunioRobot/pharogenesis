testRequirement
  "
  self debug: #testRequirement
  "
  | class |
  class := Object
            subclass: #AClassForTest
            instanceVariableNames: ''
            classVariableNames: ''
            poolDictionaries: ''
            category: self class category.
  [
   class compile: 'call
                    ^ self isCalled'.
   self assert: (class requiredSelectors includes: #isCalled).


   class compile: 'isCalled
                    ^ 1'.
   "Fail here:"
   self deny: (class requiredSelectors includes: #isCalled)]

  ensure: [class removeFromSystem] 