show7

    " B3DDemoSolids new show7"

     | view |

  self createScene7.
  (view := B3DTutorialScenePresenterMorph new)
     source: self description: #descriptionScene7;
     scene: scene.
  view clearColor: (Color gray: 0.8).
  view rotateX: 25.4.
  view openInSystemWindow.