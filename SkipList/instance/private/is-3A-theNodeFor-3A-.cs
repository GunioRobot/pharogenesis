is: node theNodeFor: key 
        node ifNil: [^ false].
        node == self ifTrue: [^ false].
        
        ^ self is: node key equalTo: key