testSelect
	"this is a non regression test for http://bugs.squeak.org/view.php?id=6535"
	
	| ks ks2 |
	
	"Creare a KeyedSet"
	ks := KeyedSet keyBlock: [:e | e asInteger \\ 4].
	ks addAll: #(1.2 1.5 3.8 7.7 9.1 12.4 13.25 14.0 19.2 11.4).
	
	"There is non more than 4 possible keys (0 1 2 3)"
	self assert: ks size <= 4.
	
	"Select some elements"
	ks2 := ks select: [:e | e fractionPart > 0.5].

	"If keyBlock was preserved, then still no more than 4 keys..."
	ks2 addAll: #(1.2 1.5 3.8 7.7 9.1 12.4 13.25 14.0 19.2 11.4).
	self assert: ks size <= 4.