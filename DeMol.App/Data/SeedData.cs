using DeMol.Domain;
using Microsoft.EntityFrameworkCore;

namespace DeMol.App.Data;

public class SeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
         
        var game = new Game
        {
            Id = 1
        };

        var votingRound =
            new VotingRound
            {
                GameId = 1,
                Id = 1,
                Round = 1,
                EndTime = DateTime.ParseExact("31/03/2024 20:00", "dd/MM/yyyy HH:mm", null),
            };

        var candidates = new List<Candidate>
            {

                new Candidate
                {
                    GameId = 1, Id = 1, Name = "Bernard",
                    PhotoUrl =
                        "https://wmimages.goplay.be/styles/f3d8f28cbac6369d15c66e328ab3944d4bcd3510/meta/bdm24nieuw-saho7d.jpg?style=W3sianBlZyI6eyJxdWFsaXR5Ijo4NX19LHsicmVzaXplIjp7ImZpdCI6ImNvdmVyIiwid2lkdGgiOjE2MCwiaGVpZ2h0IjoxNjAsImdyYXZpdHkiOm51bGwsIndpdGhvdXRFbmxhcmdlbWVudCI6ZmFsc2V9fV0=&sign=ea28199490bd4cfb4d764ba5911db6f94f52415997f17b3ed256e048c38af881"
                },
                new Candidate
                {
                    GameId = 1, Id = 2, Name = "Marta(coco)",
                    PhotoUrl =
                        "https://wmimages.goplay.be/styles/f3d8f28cbac6369d15c66e328ab3944d4bcd3510/meta/mcdm24nieuw-sahovx.jpg?style=W3sianBlZyI6eyJxdWFsaXR5Ijo4NX19LHsicmVzaXplIjp7ImZpdCI6ImNvdmVyIiwid2lkdGgiOjE2MCwiaGVpZ2h0IjoxNjAsImdyYXZpdHkiOm51bGwsIndpdGhvdXRFbmxhcmdlbWVudCI6ZmFsc2V9fV0=&sign=27a5ac56329b8ee476b7b687583a78e9893539d8685574f3e143531a93e8e0d1"
                },
                new Candidate
                {
                    GameId = 1, Id = 3, Name = "Philippe",
                    PhotoUrl =
                        "https://wmimages.goplay.be/styles/f3d8f28cbac6369d15c66e328ab3944d4bcd3510/meta/pdm24nieuw-sahp1j.jpg?style=W3sianBlZyI6eyJxdWFsaXR5Ijo4NX19LHsicmVzaXplIjp7ImZpdCI6ImNvdmVyIiwid2lkdGgiOjE2MCwiaGVpZ2h0IjoxNjAsImdyYXZpdHkiOm51bGwsIndpdGhvdXRFbmxhcmdlbWVudCI6ZmFsc2V9fV0=&sign=c02d5fab06f14ca3982627b67c48b0c3055bed691e6dbf3d1fc953746429b47b"
                },
                new Candidate
                {
                    GameId = 1, Id = 4, Name = "Senne",
                    PhotoUrl =
                        "https://wmimages.goplay.be/styles/f3d8f28cbac6369d15c66e328ab3944d4bcd3510/meta/sdm24nieuw-sahp3m.jpg?style=W3sianBlZyI6eyJxdWFsaXR5Ijo4NX19LHsicmVzaXplIjp7ImZpdCI6ImNvdmVyIiwid2lkdGgiOjE2MCwiaGVpZ2h0IjoxNjAsImdyYXZpdHkiOm51bGwsIndpdGhvdXRFbmxhcmdlbWVudCI6ZmFsc2V9fV0=&sign=ee19c47e877988a2b283fc72a0f555aaaca5ba432e55109ecb616557aadc35bb"
                },
                new Candidate
                {
                    GameId = 1, Id = 5, Name = "Lynn",
                    PhotoUrl =
                        "https://wmimages.goplay.be/styles/f3d8f28cbac6369d15c66e328ab3944d4bcd3510/meta/ldm24nieuw-sahoti.jpg?style=W3sianBlZyI6eyJxdWFsaXR5Ijo4NX19LHsicmVzaXplIjp7ImZpdCI6ImNvdmVyIiwid2lkdGgiOjE2MCwiaGVpZ2h0IjoxNjAsImdyYXZpdHkiOm51bGwsIndpdGhvdXRFbmxhcmdlbWVudCI6ZmFsc2V9fV0=&sign=5ade24f01e60fca9ca7a404fe4318eb08ebce2bff20c499f09d20d41730c60c1"
                },
                new Candidate
                {
                    GameId = 1, Id = 6, Name = "Stéphanie",
                    PhotoUrl =
                        "https://wmimages.goplay.be/styles/f3d8f28cbac6369d15c66e328ab3944d4bcd3510/meta/sbdm24nieuw-sahp5a.jpg?style=W3sianBlZyI6eyJxdWFsaXR5Ijo4NX19LHsicmVzaXplIjp7ImZpdCI6ImNvdmVyIiwid2lkdGgiOjE2MCwiaGVpZ2h0IjoxNjAsImdyYXZpdHkiOm51bGwsIndpdGhvdXRFbmxhcmdlbWVudCI6ZmFsc2V9fV0=&sign=6d07da5829f1f6620aec4ad33e4a8cb713ca95f1f13848c244c613076e548575"
                },
                new Candidate
                {
                    GameId = 1, Id = 7, Name = "Charlotte",
                    PhotoUrl =
                        "https://wmimages.goplay.be/styles/f3d8f28cbac6369d15c66e328ab3944d4bcd3510/meta/cdm24nieuw-sahomm.jpg?style=W3sianBlZyI6eyJxdWFsaXR5Ijo4NX19LHsicmVzaXplIjp7ImZpdCI6ImNvdmVyIiwid2lkdGgiOjE2MCwiaGVpZ2h0IjoxNjAsImdyYXZpdHkiOm51bGwsIndpdGhvdXRFbmxhcmdlbWVudCI6ZmFsc2V9fV0=&sign=440250844d35d1571751fc27ebae8db86274e75d5ebbc2f7aff4c59f399566a6"
                },
                new Candidate
                {
                    GameId = 1, Id = 8, Name = "Michaël",
                    PhotoUrl =
                        "https://wmimages.goplay.be/styles/f3d8f28cbac6369d15c66e328ab3944d4bcd3510/meta/mdm24nieuw-sahoy0.jpg?style=W3sianBlZyI6eyJxdWFsaXR5Ijo4NX19LHsicmVzaXplIjp7ImZpdCI6ImNvdmVyIiwid2lkdGgiOjE2MCwiaGVpZ2h0IjoxNjAsImdyYXZpdHkiOm51bGwsIndpdGhvdXRFbmxhcmdlbWVudCI6ZmFsc2V9fV0=&sign=d5961367e02cb4504d4798a44acd094671bed56bc5b14a2dfc3b968f31ab7343"
                },
                new Candidate
                {
                    GameId = 1, Id = 9, Name = "Karolien",
                    PhotoUrl =
                        "https://wmimages.goplay.be/styles/f3d8f28cbac6369d15c66e328ab3944d4bcd3510/meta/kdm24nieuw-sahora.jpg?style=W3sianBlZyI6eyJxdWFsaXR5Ijo4NX19LHsicmVzaXplIjp7ImZpdCI6ImNvdmVyIiwid2lkdGgiOjE2MCwiaGVpZ2h0IjoxNjAsImdyYXZpdHkiOm51bGwsIndpdGhvdXRFbmxhcmdlbWVudCI6ZmFsc2V9fV0=&sign=af1491127e180258c741ec809cc848e284a5a7c00e2d2d0633c3a5e03465aebb"
                },
                new Candidate
                {
                    GameId = 1, Id = 10, Name = "Gillian",
                    PhotoUrl =
                        "https://wmimages.goplay.be/styles/f3d8f28cbac6369d15c66e328ab3944d4bcd3510/meta/afvaller1roodscherm-savf4v.jpg?style=W3sianBlZyI6eyJxdWFsaXR5Ijo4NX19LHsicmVzaXplIjp7ImZpdCI6ImNvdmVyIiwid2lkdGgiOjE2MCwiaGVpZ2h0IjoxNjAsImdyYXZpdHkiOm51bGwsIndpdGhvdXRFbmxhcmdlbWVudCI6ZmFsc2V9fV0=&sign=96ec0857ab9ccbdb15371533ff4c6ee5e9444a4d595ea7a5db5e3a748c09aad2",
                    IsActive = false
                }

            };

        
        modelBuilder.Entity<Game>().HasData(game);
        modelBuilder.Entity<VotingRound>().HasData(votingRound);
        modelBuilder.Entity<Candidate>().HasData(candidates);

    }
}