initializeCenterScores
	"ChessPlayer initialize"
	PieceCenterScores _ Array new: 6.
	1 to: 6 do:[:i| PieceCenterScores at: i put: (ByteArray new: 64)].
	PieceCenterScores at: Knight put:
		#(
			-4	0	0	0	0	0	0	-4
			-4	0	2	2	2	2	0	-4
			-4	2	3	2	2	3	2	-4
			-4	1	2	5	5	2	2	-4
			-4	1	2	5	5	2	2	-4
			-4	2	3	2	2	3	2	-4
			-4	0	2	2	2	2	0	-4
			-4	0	0	0	0	0	0	-4
		).
	PieceCenterScores at: Bishop put:
		#(
			-2	-2	-2	-2	-2	-2	-2	-2
			-2	0	0	0	0	0	0	-2
			-2	0	1	1	1	1	0	-2
			-2	0	1	2	2	1	0	-2
			-2	0	1	2	2	1	0	-2
			-2	0	1	1	1	1	0	-2
			-2	0	0	0	0	0	0	-2
			-2	-2	-2	-2	-2	-2	-2	-2
		).
	PieceCenterScores at: Queen put:
		#(
			-3	0	0	0	0	0	0	-3
			-2	0	0	0	0	0	0	-2
			-2	0	1	1	1	1	0	-2
			-2	0	1	2	2	1	0	-2
			-2	0	1	2	2	1	0	-2
			-2	0	1	1	1	1	0	-2
			-2	0	0	0	0	0	0	-2
			-3	0	0	0	0	0	0	-3
		).