shortStack
	"Answer a String showing the top four contexts on my sender chain."
	| shortStackStream |
	shortStackStream _ WriteStream on: (String new: 400).
	(self stackOfSize: 5) do: 
		[:item | shortStackStream print: item; cr].
	^shortStackStream contents