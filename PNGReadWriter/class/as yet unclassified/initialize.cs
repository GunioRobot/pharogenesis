initialize
	"
	PNGReadWriter initialize
	"

	BPP _ {	#(1 2 4 8 16).
			#(0 0 0 0 0).
			#(0 0 0 24 48).
			#(1 2 4 8 0).
			#(0 0 0 16 32).
			#(0 0 0 0 0).
			#(0 0 0 32 64).
			#(0 0 0 0 0) }.

	BlockHeight _ #(8 8 4 4 2 2 1).
	BlockWidth _ #(8 4 4 2 2 1 1)
