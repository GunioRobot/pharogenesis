openAsMorph
  " B3DTutorialPresenter openAsMorph "

   | model topView diagramView explanationView |

  topView := (SystemWindow labelled: 'Tutorial Presenter') model: (model := self new).
  diagramView := B3DTutorialScenePresenterMorph new.
  topView addMorph: diagramView
            fullFrame: (LayoutFrame fractions: (0@0 corner: 1.0@1.0) ).

  topView openInWorldExtent: 500 @500