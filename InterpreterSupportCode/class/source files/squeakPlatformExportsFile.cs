squeakPlatformExportsFile

	^ '/* This file is for extra (platform) specific declarations of exported functions.
   The general format is a list of XFN(name), referring to the extra exports that
   should be listed in the internal primitive table. As an example, two extra
   definitions required by the Unix VM would look like:

   XFN(SetSocketPollingFunction)
   XFN(SetSoundPollingFunction)
*/

#ifdef macintosh
//#define PLUGIN
#ifdef PLUGIN
/* Plugin support primitives
   We should make these primitives a proper plugin
   but right now we just need the exports. */
XFN(primitivePluginBrowserReady)
XFN(primitivePluginRequestURLStream)
XFN(primitivePluginRequestURL)
XFN(primitivePluginRequestFileHandle)
XFN(primitivePluginDestroyRequest)
XFN(primitivePluginRequestState)
#endif
#endif /* macintosh */
'