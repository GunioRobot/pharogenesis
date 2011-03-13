testFinalizationOfEquals
	"self run: #testFinalizationOfEquals"
	
	| bag o |
	bag := IdentityBag new.
	1 to: 5 do: [:n | o := n asString copy. bag add: n. o toFinalizeSend: #remove: to: bag with: n].
	1 to: 5 do: [:n | o := n asString copy. bag add: n. o toFinalizeSend: #remove: to: bag with: n].
	Smalltalk garbageCollect.
	1 to: 5 do: [:n | self deny: (bag includes: n)]
