shortStack
	"Answer a String showing the top four contexts on my sender chain."
	| shortStackStream |
	shortStackStream _ WriteStream on: (String new: 55*10).
	(self stackOfSize: 10) do: 
		[:item | shortStackStream print: item; cr].
	^shortStackStream contents