willStore
	"Answer whether the next bytecode is a store or store-pop"

	| byte |
	byte _ self method at: pc.
	^(byte between: 96 and: 132) and: [
		byte <= 111 or: [byte >= 129 and: [
			byte <= 130 or: [byte = 132 and: [
				(self method at: pc+1) >= 160]]]]]