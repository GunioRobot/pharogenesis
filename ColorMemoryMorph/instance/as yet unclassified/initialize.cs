initialize
	super initialize.
	current _ 6.
	onVector _ Array new: 256 withAll: false.
	onVector at: current put: true.
	borderColor _ Color black.
	borderWidth _ 1.
	cellSize _ 8@8.	"includes 1 pixel spacer"
	bounds _ bounds origin extent: cellSize * 16 + (1@1).
	StdToMine ifNil: [self classInit].