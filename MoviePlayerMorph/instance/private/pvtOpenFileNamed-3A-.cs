pvtOpenFileNamed: fName
	| f w h d n m |
	self stopRunning.
	fName = movieFileName ifTrue: [^ self].  "No reopen necessary on same file"

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
	(Smalltalk extraVMMemory < self fileByteCountPerFrame) ifTrue:
		[^ PopUpMenu notify:
'Playing movies in Squeak requires that extra memory be allocated
for asynchronous file IO.  This particular movie requires a buffer of
' ,
(self fileByteCountPerFrame printString) , ' bytes, but you only have ' , (Smalltalk extraVMMemory printString) , ' allocated.
You can evaluate ''Smalltalk extraVMMemory'' to check your allocation,
and ''Smalltalk extraVMMemory: 485000'' or the like to increase your allocation.
Note that raising your allocation in this way only marks your image as
needing this much, so you must then save, quit, and start over again
before you can run this movie.  Good luck.'].
