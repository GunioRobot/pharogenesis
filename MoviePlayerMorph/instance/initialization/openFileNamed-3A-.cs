openFileNamed: fName
	| f w h d n m |
	movieFileName _ fName.
	"Read movie file parameters from 128-byte header...
		(records follow as {N=int32, N words}*)"
	f _ (FileStream oldFileNamed: movieFileName) binary.
		f nextInt32.
		w _ f nextInt32.
		h _ f nextInt32.
		d _ f nextInt32.
		n _ f nextInt32.
		m _ f nextInt32.
		f close.
	pageSize _ frameSize _ w@h.
	frameDepth _ d.
	frameCount _ n.
	frameNumber _ 1.
	playDirection _ 0.
	msAtLastSync _ 0.
	msPerFrame _ m/1000.0.
	self makeMyPage.
	self goToPage: 1