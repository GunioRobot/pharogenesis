methodsIn: cls callingMethodsDefinedIn: classes 
	"Give collection matching (m1, m2) where: 
	
		- m1 is defined in C 
	
		- m2 is defined in classes 
	
		- m2 called in m1 of C, 

		- and m2 not defined in C"
	
	"We made the following assumption: If a method foo is in defined in cls  
	and in classes, then if cls call foo, then it calls its own"

	| methodsCalled allMethodsDefined ans |
	methodsCalled := self methodsCalledAndCalleeForClass: cls.
	allMethodsDefined := Set new.
	classes
		do: [:clss | allMethodsDefined
				addAll: (self methodsDefinedForClass: clss)].
	ans := methodsCalled
				select: [:calleeCalled | (self doesClass: cls define: calleeCalled second) not
						and: [allMethodsDefined includes: calleeCalled second]].
	^ ans