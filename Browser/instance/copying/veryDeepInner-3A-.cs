veryDeepInner: deepCopier
	"Copy all of my instance variables.  Some need to be not copied at all, but shared.  See DeepCopier class comment."

super veryDeepInner: deepCopier.
"systemOrganizer _ systemOrganizer. 	clone has the old value. we share it"
"classOrganizer _ classOrganizer		clone has the old value. we share it"
"metaClassOrganizer 	_ metaClassOrganizer	clone has the old value. we share it"
systemCategoryListIndex _ systemCategoryListIndex veryDeepCopyWith: deepCopier.
classListIndex _ classListIndex veryDeepCopyWith: deepCopier.
messageCategoryListIndex _ messageCategoryListIndex veryDeepCopyWith: deepCopier.
messageListIndex _ messageListIndex veryDeepCopyWith: deepCopier.
editSelection _ editSelection veryDeepCopyWith: deepCopier.
metaClassIndicated _ metaClassIndicated veryDeepCopyWith: deepCopier.
