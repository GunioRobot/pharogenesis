openInSystemWindow

  | topView |

  topView := SystemWindow labelled: 'tutorial'.
  topView addMorph: self
            fullFrame: (LayoutFrame fractions: (0 @ 0 corner: 1.0 @ 0.7)).
  topView addMorph: (PluggableTextMorph on: self text: #contents accept: #acceptContents:
			readSelection: nil menu: #codePaneMenu:shifted:)
		frame: (0@0.7 corner: 1@1).
  topView openInWorldExtent: 400 @ 500.