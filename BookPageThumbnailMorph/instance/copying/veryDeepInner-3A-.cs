veryDeepInner: deepCopier
	"Copy all of my instance variables.  Some need to be not copied at all, but shared.  	Warning!!  Every instance variable defined in this class must be handled.  We must also implement veryDeepFixupWith:.  See DeepCopier class comment."

super veryDeepInner: deepCopier.
"page _ page.		Weakly copied"
pageNumber _ pageNumber veryDeepCopyWith: deepCopier.
"bookMorph _ bookMorph.		All weakly copied"
flipOnClick _ flipOnClick veryDeepCopyWith: deepCopier. 