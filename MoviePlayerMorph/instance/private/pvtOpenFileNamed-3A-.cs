pvtOpenFileNamed: fName
	"Private - open on the movie file iof the given name"

	| f w h d n m |
	self stopRunning.
	fName = movieFileName ifTrue: [^ self].  "No reopen necessary on same file"

	movieFileName := fName.
	"Read movie file parameters from 128-byte header...
		(records follow as {N=int32, N words}*)"
	f := (FileStream oldFileNamed: movieFileName) binary.
		f nextInt32.
		w := f nextInt32.
		h := f nextInt32.
		d := f nextInt32.
		n := f nextInt32.
		m := f nextInt32.
		f close.
	pageSize := frameSize := w@h.
	frameDepth := d.
	frameCount := n.
	frameNumber := 1.
	playDirection := 0.
	msAtLastSync := 0.
	msPerFrame := m/1000.0.
	self makeMyPage.
	(SmalltalkImage current platformName = 'Mac OS') ifTrue:[
		(SmalltalkImage current extraVMMemory < self fileByteCountPerFrame) ifTrue:
			[^ self inform:
'Playing movies in Squeak requires that extra memory be allocated
for asynchronous file IO.  This particular movie requires a buffer of
' ,
(self fileByteCountPerFrame printString) , ' bytes, but you only have ' , (SmalltalkImage current extraVMMemory printString) , ' allocated.
You can evaluate ''SmalltalkImage current extraVMMemory'' to check your allocation,
and ''SmalltalkImage current extraVMMemory: 485000'' or the like to increase your allocation.
Note that raising your allocation in this way only marks your image as
needing this much, so you must then save, quit, and start over again
before you can run this movie.  Good luck.']].
