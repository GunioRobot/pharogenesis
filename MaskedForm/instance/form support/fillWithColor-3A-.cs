fillWithColor: aColor
	"Pass this message on to the receiver's figure form.  6/10/96 sw
	Watch out if not changing the mask at the same time.  See colorAt:Put:  6/26/96 tk"

	theForm fillWithColor: aColor.
	mask fillWithColor: Color black.