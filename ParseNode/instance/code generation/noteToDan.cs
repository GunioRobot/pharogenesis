noteToDan
	"Bytecode 132 has now been redefined as DoubleExtendedDoAnything
		byte2				byte3		Operation
(hi 3 bits)  (lo 5 bits)
	0		nargs			lit index	Send Literal Message 0-255
	1		nargs			lit index	Super-Send Lit Msg 0-255
	2		ignored			rcvr index	Push Receiver Variable 0-255
	3		ignored			lit index	Push Literal Constant 0-255
	4		ignored			lit index	Push Literal Variable 0-255
	5		ignored			rcvr index	Store Receiver Variable 0-255
	6		ignored			rcvr index	Store-pop Receiver Variable 0-255
	7		ignored			lit index	Store Literal Variable 0-255"

	"Bytecode 134 has also been redefined as a second extended send
	that can access literals up to 64 for nargs up to 3.  It is just like
	131, except that the extendion byte is aallllll instead of aaalllll,
	where aaa are bits of argument count, and lll are bits of literal index."

	"What remains is to start compiling and using these operations...
	First compile 2, 5, 6, and test on a class with >63 inst vars.
	Note that quick-returns already work above 63.
	Then compile 3, 4, 7, and test on a method with > 63 literals."
