compressWithTable: tokens
	"Return a string with all substrings that occur in tokens replaced
	by a character with ascii code = 127 + token index.
	This will work best if tokens are sorted by size.
	Assumes this string contains no characters > 127, or that they
	are intentionally there and will not interfere with this process."
	| str null finalSize start result ri c ts |
	null _ Character value: 0.
	str _ self copyFrom: 1 to: self size.  "Working string will get altered"
	finalSize _ str size.
	tokens doWithIndex:
		[:token :tIndex |
		start _ 1.
		[(start _ str findString: token startingAt: start) > 0]
			whileTrue:
			[ts _ token size.
			((start + ts) <= str size
				and: [(str at: start + ts) = $  and: [tIndex*2 <= 128]])
				ifTrue: [ts _ token size + 1.  "include training blank"
						str at: start put: (Character value: tIndex*2 + 127)]
				ifFalse: [str at: start put: (Character value: tIndex + 127)].
			str at: start put: (Character value: tIndex + 127).
			1 to: ts-1 do: [:i | str at: start+i put: null].
			finalSize _ finalSize - (ts - 1).
			start _ start + ts]].
	result _ String new: finalSize.
	ri _ 0.
	1 to: str size do:
		[:i | (c _ str at: i) = null ifFalse: [result at: (ri _ ri+1) put: c]].
	^ result