hash
	"Hash is re-implemented because #= is re-implemented"
	^(position hash bitXor: texCoord hash) bitXor:
		(normal hash bitXor: color hash)