storeExports: exports on: aFilename
	| s |
	"Store the exports on the given file"
	s _ CrLfFileStream newFileNamed: aFilename.
	s nextPutAll:'/* This is an automatically generated table of all named primitive in the VM */'; cr;cr.

	s nextPutAll:'/* Function prototypes */'; cr.
	exports do:[:assoc|
		assoc value do:[:primName|
			s nextPutAll:'int '.
			assoc key size > 0 ifTrue:[
				s nextPutAll: assoc key; nextPutAll:'_'].
			s nextPutAll: primName; nextPutAll:'(void);'; cr.
		].
	].
	s nextPutAll:'/* extra (platform specific) prototypes */'; cr.
	s nextPutAll:'#define XFN(name) int name(void);'; cr.
	s nextPutAll:'#define XFN2(module, name) int module##_##name(void);'; cr.
	s nextPutAll:'#include "platform.exports"'; cr.
	s nextPutAll:'#undef XFN'; cr.
	s nextPutAll:'#undef XFN2'; cr.
	s cr; cr.

	s nextPutAll:'/* Function names */'; cr.
	s nextPutAll:'char *internalPrimitiveNames[][2] = {';cr.
	exports do:[:assoc|
		assoc value do:[:primName|
			s nextPutAll:'{ "'; nextPutAll: assoc key; nextPutAll:'", '.
			s nextPutAll:'"'; nextPutAll: primName; nextPutAll:'" },'; cr.
		].
	].
	s nextPutAll:'/* extra (platform specific) names */'; cr.
	s nextPutAll:'#define XFN(name) { "", #name },'; cr.
	s nextPutAll:'#define XFN2(module, name) { #module, #name },'; cr.
	s nextPutAll:'#include "platform.exports"'; cr.
	s nextPutAll:'#undef XFN'; cr.
	s nextPutAll:'#undef XFN2'; cr.
	s nextPutAll:'{ NULL, NULL }'; cr; nextPutAll:'};'.
	s cr; cr.

	s nextPutAll:'/* Function addresses */'; cr.
	s nextPutAll:'void *internalPrimitiveAddresses[] = {'; cr.
	exports do:[:assoc|
		assoc value do:[:primName|
			s nextPutAll:'(void*)'.
			assoc key size > 0 ifTrue:[
				s nextPutAll: assoc key; nextPutAll:'_'].
			s nextPutAll: primName; nextPutAll:','; cr.
		].
	].
	s nextPutAll:'/* extra (platform specific) addresses */'; cr.
	s nextPutAll:'#define XFN(name) (void*) name,'; cr.
	s nextPutAll:'#define XFN2(module, name) (void*) module##_##name,'; cr.
	s nextPutAll:'#include "platform.exports"'; cr.
	s nextPutAll:'#undef XFN'; cr.
	s nextPutAll:'#undef XFN2'; cr.
	s nextPutAll:'NULL'; cr; nextPutAll:'};'.
	s cr; cr.
	s close.