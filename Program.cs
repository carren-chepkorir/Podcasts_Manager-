using System;
using System.Collections.Generic;

namespace PodcastManager
{
    public class Podcast
    {
        public int PodcastId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Host { get; set; }
        public string Url { get; set; }
        public DateTime PublishedDate { get; set; }
        // Additional properties, such as duration, image, etc.
    }

    public class Episode
    {
        public int EpisodeId { get; set; }
        public int PodcastId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AudioUrl { get; set; }
        public DateTime PublishedDate { get; set; }
        // Additional properties, such as duration, image, etc.
    }

    public class PodcastManager
    {
        private List<Podcast> podcasts;
        private List<Episode> episodes;

        public PodcastManager()
        {
            podcasts = new List<Podcast>();
            episodes = new List<Episode>();
        }

        public void AddPodcast(Podcast podcast)
        {
            podcasts.Add(podcast);
        }

        public void AddEpisode(int podcastId, Episode episode)
        {
            episode.PodcastId = podcastId;
            episodes.Add(episode);
        }

        public void ListPodcasts()
        {
            Console.WriteLine("Podcasts:");
            foreach (var podcast in podcasts)
            {
                Console.WriteLine($"ID: {podcast.PodcastId}");
                Console.WriteLine($"Title: {podcast.Title}");
                Console.WriteLine($"Host: {podcast.Host}");
                Console.WriteLine();
            }
        }

        public void ListEpisodes(int podcastId)
        {
            var podcastEpisodes = episodes.FindAll(e => e.PodcastId == podcastId);
            Console.WriteLine($"Episodes for Podcast ID: {podcastId}");
            foreach (var episode in podcastEpisodes)
            {
                Console.WriteLine($"ID: {episode.EpisodeId}");
                Console.WriteLine($"Title: {episode.Title}");
                Console.WriteLine($"Published Date: {episode.PublishedDate}");
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PodcastManager manager = new PodcastManager();

            // Create some podcasts
            Podcast podcast1 = new Podcast
            {
                PodcastId = 1,
                Title = "Podcast 1",
                Host = "Host 1",
                Url = "https://example.com/podcast1",
                PublishedDate = DateTime.Now
            };

            Podcast podcast2 = new Podcast
            {
                PodcastId = 2,
                Title = "Podcast 2",
                Host = "Host 2",
                Url = "https://example.com/podcast2",
                PublishedDate = DateTime.Now
            };

            // Add the podcasts
            manager.AddPodcast(podcast1);
            manager.AddPodcast(podcast2);

            // Create some episodes
            Episode episode1 = new Episode
            {
                EpisodeId = 1,
                Title = "Episode 1",
                AudioUrl = "https://example.com/episode1.mp3",
                PublishedDate = DateTime.Now
            };

            Episode episode2 = new Episode
            {
                EpisodeId = 2,
                Title = "Episode 2",
                AudioUrl = "https://example.com/episode2.mp3",
                PublishedDate = DateTime.Now
            };

            // Add the episodes to the corresponding podcast
            manager.AddEpisode(1, episode1);
            manager.AddEpisode(2, episode2);

            // List all podcasts
            manager.ListPodcasts();

            // List episodes for a specific podcast
            manager.ListEpisodes(1);

            Console.ReadLine();
        }
    }
}

